﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OmegaConfig.Resources {
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
    internal class ErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OmegaConfig.Resources.ErrorMessages", typeof(ErrorMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property name is already used..
        /// </summary>
        internal static string DuplicatedPropertyName {
            get {
                return ResourceManager.GetString("DuplicatedPropertyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sequence is already used..
        /// </summary>
        internal static string DuplicatedSequence {
            get {
                return ResourceManager.GetString("DuplicatedSequence", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property can&apos;t be null..
        /// </summary>
        internal static string PropertyIsNull {
            get {
                return ResourceManager.GetString("PropertyIsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is higher than upper bound..
        /// </summary>
        internal static string ValueHigherThanUpperBound {
            get {
                return ResourceManager.GetString("ValueHigherThanUpperBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is incompatible with current value or default value..
        /// </summary>
        internal static string ValueIncompatibleWithSetValues {
            get {
                return ResourceManager.GetString("ValueIncompatibleWithSetValues", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is lower than lower bound..
        /// </summary>
        internal static string ValueLowerThanLowerBound {
            get {
                return ResourceManager.GetString("ValueLowerThanLowerBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be equal to or greater than zero..
        /// </summary>
        internal static string ValueMustBeEqualOrGreaterThanZero {
            get {
                return ResourceManager.GetString("ValueMustBeEqualOrGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value must be greater than zero..
        /// </summary>
        internal static string ValueMustBeGreaterThanZero {
            get {
                return ResourceManager.GetString("ValueMustBeGreaterThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value is outside the bounds..
        /// </summary>
        internal static string ValueOutOfBounds {
            get {
                return ResourceManager.GetString("ValueOutOfBounds", resourceCulture);
            }
        }
    }
}