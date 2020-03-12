using FractalPainting.App;

namespace FractalPainting.Infrastructure.UiActions
{
    public interface IUiAction
    {
        Category Category { get; }
        string Name { get; }
        string Description { get; }
        void Perform();
    }
}