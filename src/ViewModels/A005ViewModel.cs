using MetaFrm.MVVM;

namespace MetaFrm.Management.Razor.ViewModels
{
    /// <summary>
    /// A005ViewModel
    /// </summary>
    public partial class A005ViewModel : BaseViewModel
    {
        /// <summary>
        /// FirebaseAdminServiceAesEncryptKey
        /// </summary>
        public string FirebaseAdminServiceAesEncryptKey { get; set; } = string.Empty;

        /// <summary>
        /// FirebaseAdminServiceAesEncryptIV
        /// </summary>
        public string FirebaseAdminServiceAesEncryptIV { get; set; } = string.Empty;

        /// <summary>
        /// FirebaseAdminServiceAesEncryptString
        /// </summary>
        public string FirebaseAdminServiceAesEncryptString { get; set; } = string.Empty;

        /// <summary>
        /// FirebaseAdminServiceAesDecryptString
        /// </summary>
        public string FirebaseAdminServiceAesDecryptString { get; set; } = string.Empty;

        /// <summary>
        /// FirebaseAdminServiceAesEncryptString1
        /// </summary>
        public string FirebaseAdminServiceAesEncryptString1 
        {
            get
            {
                if (this.FirebaseAdminServiceAesEncryptString.Length > 4000)
                    return this.FirebaseAdminServiceAesEncryptString[..4000];
                else
                    return this.FirebaseAdminServiceAesEncryptString;
            }
            set
            {
                this.FirebaseAdminServiceAesEncryptString = value;
            }
        }

        /// <summary>
        /// FirebaseAdminServiceAesEncryptString2
        /// </summary>
        public string FirebaseAdminServiceAesEncryptString2
        {
            get
            {
                if (this.FirebaseAdminServiceAesEncryptString.Length > 4000)
                    return this.FirebaseAdminServiceAesEncryptString[4000..];
                else
                    return "";
            }
            set
            {
                this.FirebaseAdminServiceAesEncryptString += value;
            }
        }


        /// <summary>
        /// DllFile
        /// </summary>
        public Microsoft.AspNetCore.Components.Forms.IBrowserFile? DllFile { get; set; }

        /// <summary>
        /// ImageBytes
        /// </summary>
        public long ImageBytes { get; set; }

        /// <summary>
        /// ImageBase64Data
        /// </summary>
        public string? ImageBase64Data { get; set; }

        /// <summary>
        /// A005ViewModel
        /// </summary>
        public A005ViewModel()
        {

        }
    }
}