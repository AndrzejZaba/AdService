using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdService.Application.Common.Interfaces;

public interface IFileImageNameService
{
    string GetFileName(string fileName, string userId, DateTime creationDateTime);
}
