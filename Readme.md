## Controller

- Lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public không được (static)
- Action có thể trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm constructor

## View

- Là file .cshtml
- View cho Action lưu tại : /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
  ...
  // {0} -> Tên Action
  // {1} -> Tên Controller
  // {2} -> Tên Area

options.ViewLocationFormats.Add("/MyView/{1}/{2}" + RazorViewEngine.ViewExtension);
...

## Truyền dữ liệu sang View

- Model
- ViewData
- ViewBag
- TempData
