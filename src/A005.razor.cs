using MetaFrm.Management.Razor.ViewModels;

namespace MetaFrm.Management.Razor
{
    /// <summary>
    /// A005
    /// </summary>
    public partial class A005
    {
        #region Variable
        internal A005ViewModel A005ViewModel { get; set; } = Factory.CreateViewModel<A005ViewModel>();
        #endregion


        private async Task JsonInputFileChangeEventArgs(Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs e)
        {
            if (e.FileCount != 1)
                return;

            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptKey.Length < 5)
            {
                this.ToastShow("Key를 5자리 이상 입력하세요.");
                return;
            }

            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptIV.Length < 5)
            {
                this.ToastShow("IV를 5자리 이상 입력하세요.");
                return;
            }

            try
            {
                using MemoryStream memoryStream = new();
                await e.File.OpenReadStream(10000 * 1024).CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                using TextReader textReader = new StreamReader(memoryStream);

                this.A005ViewModel.FirebaseAdminServiceAesEncryptString = textReader.ReadToEnd().AesEncryptToBase64String(this.A005ViewModel.FirebaseAdminServiceAesEncryptKey, this.A005ViewModel.FirebaseAdminServiceAesEncryptIV);
                this.A005ViewModel.FirebaseAdminServiceAesDecryptString = this.A005ViewModel.FirebaseAdminServiceAesEncryptString.AesDecryptorToBase64String(this.A005ViewModel.FirebaseAdminServiceAesEncryptKey, this.A005ViewModel.FirebaseAdminServiceAesEncryptIV);
            }
            catch (Exception ex)
            {
                this.ToastShow(ex.Message);
            }
        }

        private void OnAesDecryptClick()
        {
            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptKey.Length < 5)
            {
                this.ToastShow("Key를 5자리 이상 입력하세요.");
                return;
            }

            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptIV.Length < 5)
            {
                this.ToastShow("IV를 5자리 이상 입력하세요.");
                return;
            }

            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptString.Length < 5)
            {
                this.ToastShow("Aes 암호화 문자열을 5자리 이상 입력하세요.");
                return;
            }

            try
            {
                this.A005ViewModel.FirebaseAdminServiceAesDecryptString = this.A005ViewModel.FirebaseAdminServiceAesEncryptString.AesDecryptorToBase64String(this.A005ViewModel.FirebaseAdminServiceAesEncryptKey, this.A005ViewModel.FirebaseAdminServiceAesEncryptIV);
            }
            catch (Exception ex)
            {
                this.ToastShow(ex.Message);
            }
        }
        private void OnAesEncryptClick()
        {
            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptKey.Length < 5)
            {
                this.ToastShow("Key를 5자리 이상 입력하세요.");
                return;
            }

            if (this.A005ViewModel.FirebaseAdminServiceAesEncryptIV.Length < 5)
            {
                this.ToastShow("IV를 5자리 이상 입력하세요.");
                return;
            }

            if (this.A005ViewModel.FirebaseAdminServiceAesDecryptString.Length < 5)
            {
                this.ToastShow("Aes 복호화 문자열을 5자리 이상 입력하세요.");
                return;
            }

            try
            {
                this.A005ViewModel.FirebaseAdminServiceAesEncryptString = this.A005ViewModel.FirebaseAdminServiceAesDecryptString.AesEncryptToBase64String(this.A005ViewModel.FirebaseAdminServiceAesEncryptKey, this.A005ViewModel.FirebaseAdminServiceAesEncryptIV);
            }
            catch (Exception ex)
            {
                this.ToastShow(ex.Message);
            }
        }

        private async Task InputFileChangeEventArgs(Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs e)
        {
            if (e.FileCount != 1)
                return;

            byte[] bytes;

            try
            {
                this.A005ViewModel.DllFile = e.File;
                this.A005ViewModel.ImageBytes = this.A005ViewModel.DllFile.Size;

                using MemoryStream memoryStream = new();
                await this.A005ViewModel.DllFile.OpenReadStream(10000 * 1024).CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                
                bytes = new byte[this.A005ViewModel.DllFile.Size];
                _ = await memoryStream.ReadAsync(bytes.AsMemory(0, (int)this.A005ViewModel.DllFile.Size));

                this.A005ViewModel.ImageBase64Data = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bytes));
            }
            catch (Exception ex)
            {
                this.ToastShow(ex.Message);
            }
        }
    }
}