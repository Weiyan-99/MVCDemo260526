最簡單CRUD流程

1.appsettings建立連線字串
2.Efcore反向工程
3.program依賴注入DefaultConnect服務
4.新建VM，分三個ItemVM、CreateVM、UpdateVM，有空先寫DataAnnotation
5.新增空白控制器，新增ctor參數dbContext
6.寫入Index，新增檢視(一般有小精靈的，List, ItemVM, 不用驗證)
7.Layout記得加User/Index
8.控制器寫入Create 兩個class，第二個寫[HttpPost]&VM當參數, 一定要有If(ModelState.IsValid), 新增檢視(Create, 要驗證)
9.寫入Edit兩個class, 參數int? id
第一個先檢查id是否為null,、再檢查使用者名稱null, 接下來才顯示vm
第二個參數id 跟 updateVM,檢查目前id跟VM.Id是否相同
檢查If(ModelState.IsValid,才可以update user資料
10.寫入Delete兩個class,檢查id為null,檢查有無此會員
第二個刪除確認,檢查有無此會員,不等於null就Remove
