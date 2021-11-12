using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Other
{
    public class WebRequestHeader
    {
        public string key;
        public string value;

        public WebRequestHeader(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class Utility
    {

        public static HttpClient httpClient = new HttpClient();

        private static T GetItem<T>(DataRow dataRow)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                foreach (PropertyInfo property in temp.GetProperties())
                {
                    if (property.Name == column.ColumnName)
                        property.SetValue(obj, dataRow[column.ColumnName], null);
                    else
                        continue;
                }
            }

            return obj;
        }

        public static List<T> DataTableToList<T>(DataTable dataTable)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        // To-do: Clean up request functions and put it in utility
        public static async Task<string> Get(string url, List<WebRequestHeader> webRequestHeaderList = null)
        {
            httpClient.DefaultRequestHeaders.Clear();

            using (var httpClient = new HttpClient())
            {
                if (webRequestHeaderList != null)
                {
                    foreach (WebRequestHeader header in webRequestHeaderList)
                        httpClient.DefaultRequestHeaders.Add(header.key, header.value);
                }

                HttpResponseMessage httpResponse = await httpClient.GetAsync(url);

                if (httpResponse.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Request Message Information:- \n\n" + httpResponse.RequestMessage + "\n");
                    Debug.WriteLine("Response Message Header \n\n" + httpResponse.Content.Headers + "\n");
                }
                else
                    Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);

                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        // To-do: Add exception checking
        public static async Task<string> Post(string url, string body, List<WebRequestHeader> webRequestHeaderList = null)
        {
            httpClient.DefaultRequestHeaders.Clear();

            if (webRequestHeaderList != null)
            {
                foreach (WebRequestHeader header in webRequestHeaderList)
                    httpClient.DefaultRequestHeaders.Add(header.key, header.value);
            }

            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await httpClient.PostAsync(url, httpContent);

            if (httpResponse.IsSuccessStatusCode)
            {
                Debug.WriteLine("Request Message Information:- \n\n" + httpResponse.RequestMessage + "\n");
                Debug.WriteLine("Response Message Header \n\n" + httpResponse.Content.Headers + "\n");
            }
            else
                Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);

            return await httpResponse.Content.ReadAsStringAsync();
        }

        public static async Task<string> Put(string url, string body, List<WebRequestHeader> webRequestHeaderList = null)
        {
            httpClient.DefaultRequestHeaders.Clear();

            if (webRequestHeaderList != null)
            {
                foreach (WebRequestHeader header in webRequestHeaderList)
                    httpClient.DefaultRequestHeaders.Add(header.key, header.value);
            }

            HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await httpClient.PutAsync(url, httpContent);

            if (httpResponse.IsSuccessStatusCode)
            {
                Debug.WriteLine("Request Message Information:- \n\n" + httpResponse.RequestMessage + "\n");
                Debug.WriteLine("Response Message Header \n\n" + httpResponse.Content.Headers + "\n");
            }
            else
                Console.WriteLine("{0} ({1})", (int)httpResponse.StatusCode, httpResponse.ReasonPhrase);

            return await httpResponse.Content.ReadAsStringAsync();
        }
    }
}
