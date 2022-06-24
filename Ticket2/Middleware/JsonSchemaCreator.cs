using System.IO;
using Newtonsoft.Json.Schema;

namespace Ticket2.Middleware
{
    public class JsonSchemaCreator
    {
        public JSchema ReturnJSchema(string processName)
        {
            var returnSchema = new JSchema();
            
            if (processName.Equals("sale"))
            {
                //returnSchema = JSchema.Parse(File.ReadAllText("JsonShema.txt"));
                returnSchema = JSchema.Parse(File.ReadAllText("JsonSchemas/JsonSchema.json"));
            }

            if (processName.Equals("refund"))
            {
                returnSchema = JSchema.Parse(File.ReadAllText("JsonSchemas/JsonSchemaRefund.json"));
            }

            return returnSchema;
        }
    }
}