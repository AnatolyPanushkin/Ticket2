using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;


namespace Ticket2.ValidationJson
{
   
    public static class ValidationJson
    {
        public static bool IsJsonValid(this string value)
        {
            string schemaJson = @"{
              ‘type’: ‘object’,
              ‘properties’: {
                ‘operation_type’: {
                  ‘type’: ‘string’
                },
                ‘operration_time’: {
                  ‘type’: ‘string’
                },
                ‘operation_place’: {
                  ‘type’: ‘string’
                },
                ‘passenger’: {
                  ‘type’: ‘object’,
                  ‘properties’: {
                    ‘name’: {
                      ‘type’: ‘string’
                    },
                    ‘surname’: {
                      ‘type’: ‘string’
                    },
                    ‘patronymic’: {
                      ‘type’: ‘string’
                    },
                    ‘doc_type’: {
                      ‘type’: ‘string’
                    },
                    ‘doc_number’: {
                      ‘type’: ‘string’
                    },
                    ‘birthdate’: {
                      ‘type’: ‘string’
                    },
                    ‘gender’: {
                      ‘type’: ‘string’
                    },
                    ‘passenger_type’: {
                      ‘type’: ‘string’
                    },
                    ‘ticket_number’: {
                      ‘type’: ‘string’
                    },
                    ‘ticket_type’: {
                      ‘type’: ‘integer’
                    }
                  }
                },
                ‘routes’ : {
                  ‘type’ : ‘array’,
                  ‘items’ : {
                    ‘type’ : ‘object’,
                    ‘properties’: {
                      ‘airline_code’ : {
                        ‘type’ : ‘string’
                      },
                      ‘fligth_num’ : {
                        ‘type’ : ‘integer’
                      },
                      ‘depart_place’ : {
                        ‘type’ : ‘string’
                      },
                      ‘depart_datetime’ : {
                        ‘type’ : ‘string’
                      },
                      ‘arrive_place’ : {
                        ‘type’ : ‘string’
                      },
                      ‘arrive_datetime’ : {
                        ‘type’ : ‘string’
                      },
                      ‘pnr_id’ : {
                        ‘type’ : ‘string’
                      }
                    }
                  }
                }
              }
            }";
            //JSchema schema = JSchema.Parse(schemaJson);
            /*JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(TSchema));
            schema.AllowAdditionalProperties = false;   

            JObject obj = JObject.Parse(value);
            return obj.IsValid(schema);*/
            
            
          
              /*JSchemaGenerator generator = new JSchemaGenerator();
              JSchema schema = generator.Generate(typeof(TSchema));
                              
              JObject obj = JObject.Parse(value);
              bool valid = obj.IsValid(schema);
          
              return valid;*/
              
              
              
              using (StreamReader file = File.OpenText(@"D:\Projects C#\Tickets2\Ticket2\Ticket2\JsonSchemaRefund.txt"))
              using (JsonTextReader reader = new JsonTextReader(file))
              {
                JSchema schema = JSchema.Load(reader);

                JObject obj = JObject.Parse(value);
                bool valid = obj.IsValid(schema);
          
                return valid;
              }
            
        }
    }
}

