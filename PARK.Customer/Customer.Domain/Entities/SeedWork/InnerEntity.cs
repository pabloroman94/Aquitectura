using System;

namespace Domain.Entities
{
    public abstract class InnerEntity
    {
        public string[] innerObjs { get; set; } = Array.Empty<string>();
        public string[] innerColls { get; set; } = Array.Empty<string>();
    }
}
