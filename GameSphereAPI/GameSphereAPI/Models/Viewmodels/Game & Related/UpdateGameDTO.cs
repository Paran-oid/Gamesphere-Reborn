using GameSphereAPI.Models.Site_Models.Game_Related;

namespace GameSphereAPI.Models.Viewmodels.Game___Related
{
    public record struct UpdateGameDTO(
        string Title,
        string BackgroundPath,
        string TrailerPath,
        List<string> PicturesPath,
        DateOnly releaseDate,
        decimal Price,
        string Size,
        string Description,
        string SysReq);
}