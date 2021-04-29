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
    

* .DefaultIfEmpty() don't work
 -- after --
var individualUser = from user in usersQuery
                                     from combineDetail in combineDetails
                                                      .Where(combine => combine.UserId == user.Id)
                                                      .DefaultIfEmpty(defaultDetail)
                                     select new ViewModel
                                     {
                                         UserId = user.Id,
                                         CombineAmountSum = combineDetail.Amount,
                                         CombineBettingCount = combineDetail.Count,
                                         CombineHit = combineDetail.Hit,
                                     };
 -- befaore --                                    
var individualUser = from user in usersQuery
                                     let combineDetail = combineDetails.Where(combine => combine.UserId == user.Id).FirstOrDefault()
                                     select new ViewModel
                                     {
                                         UserId = user.Id,
                                         CombineAmountSum = combineDetail == null ? default : combineDetail.Amount,
                                         CombineBettingCount = combineDetail == null ? default : combineDetail.Count,
                                         CombineHit = combineDetail == null ? default : combineDetail.Hit,
                                     };                                     
