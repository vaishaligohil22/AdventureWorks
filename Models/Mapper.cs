using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Models
{
    public static class Mapper
    {
        public static Product Map(DBModels.Product product)
        {
            return new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                ProductNumber = product.ProductNumber,
                Color = product.Color,
                StandardCost = (double)product.StandardCost,
                ListPrice = (double)product.ListPrice,
                Size = product.Size,
                Weight = product.Weight.Value,
                ProductLine = product.ProductLine,
                Class = product.Class,
                Style = product.Style
            };
        }

        public static ProductSubCategory Map(DBModels.ProductSubcategory subcategory)
        {
            return new ProductSubCategory()
            {
                ProductSubCategoryID = subcategory.ProductSubcategoryId,
                Name = subcategory.Name
            };
        }

        public static ProductCategory Map(DBModels.ProductCategory category)
        {
            return new ProductCategory()
            {
                ProductCategoryID = category.ProductCategoryId,
                Name = category.Name
            };
        }

        public static ProductPhoto Map(DBModels.ProductPhoto photo)
        {
            return new ProductPhoto()
            {
                ProductPhotoID = photo.ProductPhotoId,
                ThumbNailPhoto = Convert.ToBase64String(photo.ThumbNailPhoto),
                ThumbNailPhotoFileName = photo.ThumbnailPhotoFileName,
                LargePhoto = Convert.ToBase64String(photo.LargePhoto),
                LargePhotoFileName = photo.LargePhotoFileName
            };
        }

        public static ProductModel Map(DBModels.ProductModel model)
        {
            return new ProductModel()
            {
                ProductModelID = model.ProductModelId,
                Name = model.Name,
                CatalogDescription = model.CatalogDescription,
                Instructions = model.Instructions
            };
        }

        public static List<ProductReview> Map(List<DBModels.ProductReview> review)
        {
            return review.ConvertAll(reviewElement => new ProductReview()
            {
                ProductReviewID = reviewElement.ProductReviewId,
                ProductId = reviewElement.ProductId,
                ReviewerName = reviewElement.ReviewerName,
                ReviewDate = reviewElement.ReviewDate,
                EmailAddress = reviewElement.EmailAddress,
                Rating = reviewElement.Rating,
                Comments = reviewElement.Comments
            });
        }
    }
}
