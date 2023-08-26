﻿using GreenSale.ViewModels.Enums.BuyerPost;

namespace GreenSale.ViewModels.Models.BuyerPosts
{
    public class BuyerPostGetById
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public long UserId { get; set; }
        public string UserPhoneNumber { get; set; } = string.Empty;
        public string PostPhoneNumber { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string CapacityMeasure { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public BuyerPostEnums Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<BuyerPostImage> BuyerPostsImages { get; set; }
        public string MainImage { get; set; } = string.Empty;
    }
}
