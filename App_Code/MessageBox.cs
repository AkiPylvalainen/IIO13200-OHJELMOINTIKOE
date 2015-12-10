using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for MessageBox
/// </summary>
public class MessageBox
{
    private static Hashtable _executingPages = new Hashtable();

    public static void Show(String message)
    {
        if (!_executingPages.Contains(HttpContext.Current.Handler))
        {
            Page executingPage = HttpContext.Current.Handler as Page;

            if (executingPage != null)
            {
                Queue messageQueue = new Queue();

                messageQueue.Enqueue(message);

                _executingPages.Add(HttpContext.Current.Handler, messageQueue);

                executingPage.Unload += new EventHandler(ExecutingPage_Unload);
            }
        }
        else
        {
            Queue queue = (Queue)_executingPages[HttpContext.Current.Handler];

            queue.Enqueue(message);
        }
    }

    private static void ExecutingPage_Unload(object sender, EventArgs e)
    {
        Queue queue = (Queue)_executingPages[HttpContext.Current.Handler];

        if (queue != null)
        {
            StringBuilder sb = new StringBuilder();

            int msgCount = queue.Count;

            sb.Append(@"<script language='javascript'>");

            string msg;
            while (msgCount-- > 0)
            {
                msg = (string)queue.Dequeue();
                msg = msg.Replace("\n", "\\n");
                msg = msg.Replace("\"", "'");
                sb.Append(@"alert( """ + msg + @""" );");
            }

            sb.Append(@"</script>");

            _executingPages.Remove(HttpContext.Current.Handler);

            HttpContext.Current.Response.Write(sb.ToString());
        }
    }
}