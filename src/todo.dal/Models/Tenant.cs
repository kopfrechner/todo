using Todo.Dal.Models.Abstractions;

namespace Todo.Dal.Models
{
    /// <summary>
    /// A tenant of the system
    /// </summary>
    public class Tenant : EntityWithId
    {
        /// <summary>
        /// Name of the Tenant
        /// </summary>
        public string Name { get; set; }
    }
}