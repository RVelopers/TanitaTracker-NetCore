using System;

namespace Domain.Entities
{
    public class Module : SoftDeletableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public bool ActionCreate { get; set; }
        public bool ActionView { get; set; }
        public bool ActionEdit { get; set; }
        public bool ActionDelete { get; set; }
    }
}