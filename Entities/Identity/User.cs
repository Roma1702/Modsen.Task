using Entities.Implementation;
using Microsoft.AspNetCore.Identity;

namespace Entities.Identity;

public class User : IdentityUser<Guid>
{
    public int Age { get; set; }
    public virtual List<UserConnectionWithEvent>? ConnectionWithEvents { get; set; }
}