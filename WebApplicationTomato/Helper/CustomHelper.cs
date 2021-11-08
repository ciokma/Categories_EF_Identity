using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Text;
using WebApplicationTomato.Data;

namespace WebApplicationTomato.Helper
{
    public static class CustomHelper
    {
        public static string ShowCategories(Category category)
        {
            StringBuilder output = new StringBuilder();

            output.Append(string.Format("<ul class='{0}'>", category.ChildCategories.Any() ? "submenu dropdown-menu" : ""));

            output.Append("<li>");
            output.Append(string.Format("<a class='dropdown-item' href='#'>{0}</a>", category.Description));

            if (category.ChildCategories.Any())
            {
                foreach (var subItem in category.ChildCategories)
                {
                    //output.Append("</li>");

                    //.Append("<li>");
                    //output.Append(string.Format("<a class='dropdown-item' href='#'>{0}</a>", subItem.Description));
                    output.Append(ShowCategories(subItem));
                }
            }
            output.Append(string.Format("{0}", category.ChildCategories.Any() ? "" : "</li>"));
            output.Append(string.Format("{0}", category.ChildCategories.Any() ? "</ul>" : ""));



            return output.ToString();
        }
        public static string ShowCategory(Category category)
        {
            StringBuilder output = new StringBuilder();
            if (category.ChildCategories.Any())
            {
                output.Append("<ul class='submenu dropdown-menu'>");
                string append = AppendCategory(category);
                output.Append(append);
                output.Append(string.Format("</ul>"));

            }
            else
            {
                output.Append(string.Format("<li><a class='dropdown-item' href='#'>{0}</a></li>", category.Description));
            }

            return output.ToString();
        }
        public static string AppendCategory(Category category)
        {
            StringBuilder output = new StringBuilder();

            if (category.ChildCategories.Any())
            {
                if (category.RootCategory == null) output.Append("");
                else
                {
                    output.Append(string.Format("<li><ul class='submenu dropdown-menu'><li><a class='dropdown-item'  href=''>{0}</a></li>", category.Description));
                }
            }
            else
            {
                output.Append(string.Format("<li><a class='dropdown-item' href='#'>{0}</a></li>", category.Description));
            }


            foreach (var subItem in category.ChildCategories)
            {

                output.Append(AppendCategory(subItem));
            }
            if (category.ChildCategories.Any())
            {
                if (category.RootCategory == null) output.Append("");
                else
                {
                    output.Append(string.Format("</ul></li>"));
                }
            }
            return output.ToString();
        }
        /*
        public static string ShowCategories(Category category)
        {
            StringBuilder output = new StringBuilder();
            if (category.ChildCategories != null && category.ChildCategories.Count > 0)
            { 
                output.Append(string.Format("<ul class='dropdown-menu'>", category.ChildCategories.Any() ? "submenu dropdown-menu", "dropdown-menu"));

                output.Append("<li class='nav-item dropdown'>");
                output.Append(string.Format("<a class='dropdown-item' href='#'>{0}</a>", category.Description));

                foreach (var subItem in category.ChildCategories)
                {
                    output.Append("<li>");
                    output.Append(string.Format("<a class='dropdown-item' href='#'>{0}</a>", category.Description));
                    output.Append(ShowCategories(subItem));
                    output.Append("</li>");
                }
                output.Append("</ul>");
                output.Append("</li>");

            }
            return output.ToString();
        }
        */
    }
}
