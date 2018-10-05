using System;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;

namespace CollegeBusiness.Util
{
    public static class cWebHelper
    {
        public static HttpContext Context
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public static string GetCurrentUser
        {
            get
            {
                return WindowsIdentity.GetCurrent().Name;
            }
        }

        public static string GetRemoteIp
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return GetServerVariables(ServerVariables.HTTP_X_REAL_IP).ValueOrDefault<string>(GetServerVariables(ServerVariables.REMOTE_ADDR));
                }
                if (OperationContext.Current != null)
                {
                    return OperationContext.Current.GetRemoteIPAddress();
                }
                return null;
            }
        }

        public static string GetRemoteName
        {
            get
            {
                return Dns.GetHostEntry(GetRemoteIp).HostName;
            }
        }

        public static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        public static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }

        public static string GetServerVariables(ServerVariables value)
        {
            string str = Request.ServerVariables[value.ToString()];
            if (str == "::1")
            {
                return "127.0.0.1";
            }
            return str;
        }

        private static string GetRemoteIPAddress(this OperationContext context)
        {
            RemoteEndpointMessageProperty property = context.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            if (property == null)
            {
                return null;
            }
            if (property.Address == "::1")
            {
                return "127.0.0.1";
            }
            return property.Address;
        }

        private static T ValueOrDefault<T>(this string s, T Default)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return (T)Convert.ChangeType(s, typeof(T));
            }
            return Default;
        }
    }

    public enum ServerVariables
    {
        APPL_MD_PATH,
        APPL_PHYSICAL_PATH,
        AUTH_PASSWORD,
        AUTH_TYPE,
        AUTH_USER,
        CERT_COOKIE,
        CERT_FLAGS,
        CERT_ISSUER,
        CERT_KEYSIZE,
        CERT_SECRETKEYSIZE,
        CERT_SERIALNUMBER,
        CERT_SERVER_ISSUER,
        CERT_SERVER_SUBJECT,
        CERT_SUBJECT,
        CONTENT_LENGTH,
        CONTENT_TYPE,
        GATEWAY_INTERFACE,
        HTTPS,
        HTTPS_KEYSIZE,
        HTTPS_SECRETKEYSIZE,
        HTTPS_SERVER_ISSUER,
        HTTPS_SERVER_SUBJECT,
        INSTANCE_ID,
        INSTANCE_META_PATH,
        LOCAL_ADDR,
        LOGON_USER,
        PATH_INFO,
        PATH_TRANSLATED,
        QUERY_STRING,
        REMOTE_ADDR,
        REMOTE_HOST,
        REMOTE_USER,
        REQUEST_METHOD,
        SCRIPT_NAME,
        SERVER_NAME,
        SERVER_PORT,
        SERVER_PORT_SECURE,
        SERVER_PROTOCOL,
        SERVER_SOFTWARE,
        URL,
        HTTP_CONNECTION,
        HTTP_ACCEPT,
        HTTP_ACCEPT_ENCODING,
        HTTP_ACCEPT_LANGUAGE,
        HTTP_COOKIE,
        HTTP_HOST,
        HTTP_USER_AGENT,
        HTTP_X_REAL_IP,
        HTTP_X_FORWARDED_FOR
    }



}
