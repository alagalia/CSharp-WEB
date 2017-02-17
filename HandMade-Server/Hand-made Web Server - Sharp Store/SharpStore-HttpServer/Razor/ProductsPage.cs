﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpStore.Data.Models;

namespace Razor
{
    public class ProductsPage :Page
    {
        private const string Path = "../../content/products.html";
        private readonly IList<Knife> Knives;

        public ProductsPage(IList<Knife> knives) : base(Path)
        {
            this.Knives = knives;
        }

        public ProductsPage(string htmlPath, IList<Knife> knives ) : base(htmlPath)
        {
            this.Knives = knives;
        }

        public override string ToString()
        {
            StringBuilder knivesBuilder = new StringBuilder();

            foreach (var knife in this.Knives)
            {
                knivesBuilder.Append("<div class=\"col-sm-4\">\r\n" +
                                        "<div class=\"thumbnail\">\r\n" +
                                            $"<img src=\"{knife.ImageUrl}\" alt=\"...\">\r\n " +
                                            "<div class=\"caption\">\r\n " +
                                                $"<h3>{knife.Name}</h3>\r\n" +
                                                $"<p>${knife.Price}</p>\r\n" +
                                                "<button type=\"button\" class=\"btn btn-primary \">Buy Now</button>\r\n" +
                                            "</div>\r\n" +
                                          "</div>\r\n" +
                                         "</div>");
            }

            return String.Format(base.ToString(), knivesBuilder);
        }
    }
}