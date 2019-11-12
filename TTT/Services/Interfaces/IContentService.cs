using Microsoft.Xna.Framework.Content;
using System.Threading.Tasks;

namespace TTT.Services.Interfaces
{
    public interface IContentService
    {
        Task LoadContent(ContentManager contentManager);
    }
}
