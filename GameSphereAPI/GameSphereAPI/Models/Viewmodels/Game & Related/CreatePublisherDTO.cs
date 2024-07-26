namespace GameSphereAPI.Models.Viewmodels.Game___Related
{
    public record struct CreatePublisherDTO(
        string Name,
        decimal Rating,
        string UserID);
}