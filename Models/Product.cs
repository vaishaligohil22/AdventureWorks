/*
 * Advanture Works
 *
 * This is a sample server for Advanture Works.
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AdventureWorks.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Product : IEquatable<Product>
    { 
        /// <summary>
        /// Gets or Sets ProductId
        /// </summary>
        [Required]
        [DataMember(Name="productId")]
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets ProductNumber
        /// </summary>
        [DataMember(Name="productNumber")]
        public string ProductNumber { get; set; }

        /// <summary>
        /// Gets or Sets Color
        /// </summary>
        [DataMember(Name="color")]
        public string Color { get; set; }

        /// <summary>
        /// Gets or Sets StandardCost
        /// </summary>
        [DataMember(Name="standardCost")]
        public double StandardCost { get; set; }

        /// <summary>
        /// Gets or Sets ListPrice
        /// </summary>
        [DataMember(Name="listPrice")]
        public double ListPrice { get; set; }

        /// <summary>
        /// Size of the product
        /// </summary>
        /// <value>Size of the product</value>
        [DataMember(Name="size")]
        public string Size { get; set; }

        /// <summary>
        /// Weight of the product
        /// </summary>
        /// <value>Weight of the product</value>
        [DataMember(Name="weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or Sets ProductLine
        /// </summary>
        [DataMember(Name="productLine")]
        public string ProductLine { get; set; }

        /// <summary>
        /// Gets or Sets Class
        /// </summary>
        [DataMember(Name="class")]
        public string Class { get; set; }

        /// <summary>
        /// Gets or Sets Style
        /// </summary>
        [DataMember(Name="style")]
        public string Style { get; set; }

        /// <summary>
        /// Gets or Sets SubCategory
        /// </summary>
        [DataMember(Name="subCategory")]
        public ProductSubCategory SubCategory { get; set; }

        /// <summary>
        /// Gets or Sets Model
        /// </summary>
        [DataMember(Name="model")]
        public ProductModel Model { get; set; }

        /// <summary>
        /// Gets or Sets Photo
        /// </summary>
        [DataMember(Name="photo")]
        public ProductPhoto Photo { get; set; }

        /// <summary>
        /// Gets or Sets Review
        /// </summary>
        [DataMember(Name="review")]
        public List<ProductReview> Review { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Product {\n");
            sb.Append("  ProductId: ").Append(ProductId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ProductNumber: ").Append(ProductNumber).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
            sb.Append("  StandardCost: ").Append(StandardCost).Append("\n");
            sb.Append("  ListPrice: ").Append(ListPrice).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  ProductLine: ").Append(ProductLine).Append("\n");
            sb.Append("  Class: ").Append(Class).Append("\n");
            sb.Append("  Style: ").Append(Style).Append("\n");
            sb.Append("  SubCategory: ").Append(SubCategory).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Photo: ").Append(Photo).Append("\n");
            sb.Append("  Review: ").Append(Review).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Product)obj);
        }

        /// <summary>
        /// Returns true if Product instances are equal
        /// </summary>
        /// <param name="other">Instance of Product to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ProductId == other.ProductId ||
                    ProductId != null &&
                    ProductId.Equals(other.ProductId)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    ProductNumber == other.ProductNumber ||
                    ProductNumber != null &&
                    ProductNumber.Equals(other.ProductNumber)
                ) && 
                (
                    Color == other.Color ||
                    Color != null &&
                    Color.Equals(other.Color)
                ) && 
                (
                    StandardCost == other.StandardCost ||
                    StandardCost != null &&
                    StandardCost.Equals(other.StandardCost)
                ) && 
                (
                    ListPrice == other.ListPrice ||
                    ListPrice != null &&
                    ListPrice.Equals(other.ListPrice)
                ) && 
                (
                    Size == other.Size ||
                    Size != null &&
                    Size.Equals(other.Size)
                ) && 
                (
                    Weight == other.Weight ||
                    Weight != null &&
                    Weight.Equals(other.Weight)
                ) && 
                (
                    ProductLine == other.ProductLine ||
                    ProductLine != null &&
                    ProductLine.Equals(other.ProductLine)
                ) && 
                (
                    Class == other.Class ||
                    Class != null &&
                    Class.Equals(other.Class)
                ) && 
                (
                    Style == other.Style ||
                    Style != null &&
                    Style.Equals(other.Style)
                ) && 
                (
                    SubCategory == other.SubCategory ||
                    SubCategory != null &&
                    SubCategory.Equals(other.SubCategory)
                ) && 
                (
                    Model == other.Model ||
                    Model != null &&
                    Model.Equals(other.Model)
                ) && 
                (
                    Photo == other.Photo ||
                    Photo != null &&
                    Photo.Equals(other.Photo)
                ) && 
                (
                    Review == other.Review ||
                    Review != null &&
                    Review.SequenceEqual(other.Review)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (ProductId != null)
                    hashCode = hashCode * 59 + ProductId.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (ProductNumber != null)
                    hashCode = hashCode * 59 + ProductNumber.GetHashCode();
                    if (Color != null)
                    hashCode = hashCode * 59 + Color.GetHashCode();
                    if (StandardCost != null)
                    hashCode = hashCode * 59 + StandardCost.GetHashCode();
                    if (ListPrice != null)
                    hashCode = hashCode * 59 + ListPrice.GetHashCode();
                    if (Size != null)
                    hashCode = hashCode * 59 + Size.GetHashCode();
                    if (Weight != null)
                    hashCode = hashCode * 59 + Weight.GetHashCode();
                    if (ProductLine != null)
                    hashCode = hashCode * 59 + ProductLine.GetHashCode();
                    if (Class != null)
                    hashCode = hashCode * 59 + Class.GetHashCode();
                    if (Style != null)
                    hashCode = hashCode * 59 + Style.GetHashCode();
                    if (SubCategory != null)
                    hashCode = hashCode * 59 + SubCategory.GetHashCode();
                    if (Model != null)
                    hashCode = hashCode * 59 + Model.GetHashCode();
                    if (Photo != null)
                    hashCode = hashCode * 59 + Photo.GetHashCode();
                    if (Review != null)
                    hashCode = hashCode * 59 + Review.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
