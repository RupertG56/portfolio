namespace Portfolio.Api.Site;

public static class SiteEndpoints
{
    public static IEndpointRouteBuilder MapSiteEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var siteGroup = endpoints.MapGroup("/api/site")
            .WithTags("Site");

        siteGroup.MapGet("/", GetSiteDocument)
            .WithName("GetSiteDocument");
        //siteGroup.MapPost("/", CreateSiteDocument);
        siteGroup.MapPut("/", UpdateSiteDocument)
            .WithName("UpdateSiteDocument");
        //siteGroup.MapDelete("/", DeleteSiteDocument);

        return endpoints;
    }

    private static async Task<IResult> GetSiteDocument(ISiteService service)
    {
        var response = await service.GetAsync();
        if (!response.Success)
        {
            return Results.NotFound(response);
        }
        return Results.Ok(response);
    }

    private static async Task<IResult> UpdateSiteDocument(SiteDocument siteDocument, ISiteService service)
    {
        var response = await service.UpdateSiteDocumentAsync(siteDocument);
        if (!response.Success)
        {
            return Results.BadRequest(response);
        }
        return Results.Ok(response);
    }
}