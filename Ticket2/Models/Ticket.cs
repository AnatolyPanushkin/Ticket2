using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticket2.Models
{
    //я вынес эти классы в директорию с названием Models, так как они необходимы для реализации бизнес логики данного сервиса,
    //хоть модель и должна отвечать за логику работы с данными, но в этой конкретной архитектуре не хотелось бы добавлять сервисный слой,
    //в силу того что он станет не нужным усложнением структуры сервиса, поскольку на мой взгляд, если этот сервис не будет работать с
    //пользователями на прямую, то нет ничего страшного в том, что контроллер возьмет на себя ответственность за нашу бизнес логику, иначе он будет просто бесполезным.
    
    
    public class Ticket
    {
        public string Operation_Type { get; set; }
        
        public string Operration_Time { get; set; }
        
        public string Operation_Place { get; set; }
        
        public Passenger Passenger { get; set; }
        
        public Route[] Routes { get; set; }
        
    }
}