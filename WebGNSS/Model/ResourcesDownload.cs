using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResourcesDownload
    {
        public int ID; //主键 ID
        public string ResourceName;//文件名
        public string ResourcePath;//资源文件路径
        public int DownloadTimes; //下载次数
        public string UploadUser;//上传用户
        public DateTime UploadTime;
        public bool IsDeleted;
        public string Remark;//备注

        public ResourcesDownload()
        {
            DownloadTimes = 0;
            IsDeleted = false;
            Remark = "";

        }
    }
}
