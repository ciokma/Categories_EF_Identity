﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationTomato.Utilities {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class RsMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RsMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("WebApplicationTomato.Utilities.RsMessage", typeof(RsMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Category Description can not be empty, please add a description and continue clicking on save button..
        /// </summary>
        public static string MessageCategoryDescriptionValidation {
            get {
                return ResourceManager.GetString("MessageCategoryDescriptionValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If the category is not public then it is necessary to select a role for the category..
        /// </summary>
        public static string MessageCategoryRoleValidation {
            get {
                return ResourceManager.GetString("MessageCategoryRoleValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The category can not be created. Please contact the system administror..
        /// </summary>
        public static string MessageErrorCategory {
            get {
                return ResourceManager.GetString("MessageErrorCategory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The category has been created successfully!.
        /// </summary>
        public static string MessageSuccessCategory {
            get {
                return ResourceManager.GetString("MessageSuccessCategory", resourceCulture);
            }
        }
    }
}