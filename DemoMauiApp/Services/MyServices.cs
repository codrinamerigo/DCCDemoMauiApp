using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;



namespace DemoMauiApp.Services;

public class MyServices
{
    HttpClient httpClient;
    public MyServices() {
        this.httpClient = new HttpClient();

    }

    List<MyModel> myModelList;
    public async Task<List<MyModel>> GetGroceries()
    {
        if (myModelList?.Count > 0)
            return myModelList;

        // Online
        var response = await httpClient.GetAsync("https://dummyjson.com/products/category/");
        if (response.IsSuccessStatusCode)
        {
            myModelList = await response.Content.ReadFromJsonAsync(MyModelContext.Default.ListMyModel);
        }

        // Offline
        using var stream = await FileSystem.OpenAppPackageFileAsync("myData.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        myModelList = JsonSerializer.Deserialize(contents, MyModelContext.Default.ListMyModel);

        return myModelList;
    }


}
