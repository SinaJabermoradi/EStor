namespace EStor.Application.Services.Products.QueriesService.GetProductForSite;

public enum Ordering : byte
{
    NotOrder = 0,

    /// <summary>
    /// پربازدیدترین
    /// </summary>
    MostVisited = 1,

    /// <summary>
    /// پرفروشترین
    /// </summary>
    MostSelling = 2,

    /// <summary>
    /// محبوبترین
    /// </summary>
    MostPopular = 3,

    /// <summary>
    /// جدیدترین
    /// </summary>
    TheNewest = 4,

    /// <summary>
    /// ارزانترین
    /// </summary>
    Cheapest = 5,

    /// <summary>
    /// گرانترین
    /// </summary>
    TheMostExpensive = 6

}