1. Смена версий проектов через опции.
2. Обновление EF Core
3. Добавление отдельно Newtownson
4. Добавить  <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="3.1.0" />
5. Подключить Microsoft.AspNetCore.Authentication.JwtBearer.
6. Исправить на IHostBuilder в Program
7. app.UseAuthorization();




-------- EF Core 2.2 to 3.1 ----------------
Before

  .Where(x => x.BirthDate.GetValueOrDefault().Month == DateTime.Now.Month)

Aafter
  .Where(x => (x.BirthDate != null && x.BirthDate.Value.Month == DateTime.Now.Month) || (x.BirthDate == null && defaultMonthValue ==    DateTime.Now.Month))
  --or--
  .Where(x => x.BirthDate != null && x.BirthDate.Value.Month == DateTime.Now.Month)
    
