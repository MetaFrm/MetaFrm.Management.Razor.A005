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


        internal Microsoft.AspNetCore.Components.Forms.IBrowserFile? DllFile { get; set; }
        internal long ImageBytes;
        internal string? ImageBase64Data;
        private async Task InputFileChangeEventArgs(Microsoft.AspNetCore.Components.Forms.InputFileChangeEventArgs e)
        {
            byte[] bytes;


            if (e.FileCount == 1)
            {
                this.DllFile = e.File;
                this.ImageBytes = this.DllFile.Size;

                MemoryStream memoryStream = new();
                await this.DllFile.OpenReadStream(10000 * 1024).CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                bytes = new byte[this.DllFile.Size];
                int count = await memoryStream.ReadAsync(bytes.AsMemory(0, (int)this.DllFile.Size));

                this.ImageBase64Data = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bytes));
            }
        }
    }
}