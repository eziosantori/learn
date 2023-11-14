// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Periodic Timer
var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
var count=1;
while (await timer.WaitForNextTickAsync()){
 // do some stuff
    Console.WriteLine(count);
    if(count > 10)
        break;
    count ++;
}

// Parallel Foreach
var urls = new[] {
  "https://restcountries.com/v3.1/all?fields=name,flags",
  "https://api.publicapis.org/entries"
};
var client = new HttpClient();
await Parallel.ForEachAsync(urls, async (url, token) =>
{
  var resp = await client.GetAsync(url);
  Console.WriteLine(resp.StatusCode);
});

