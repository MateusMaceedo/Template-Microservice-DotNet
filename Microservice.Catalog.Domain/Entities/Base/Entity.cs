using System;

namespace Microservice.Catalog.Domain.Entities.Base
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTime CadastradoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
    }
}
