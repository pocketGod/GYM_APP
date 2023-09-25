import { Injectable } from '@angular/core';
import { Observable, map, of, tap } from 'rxjs';
import { HttpHandlerService } from 'src/app/common/services/http-handler.service';
import { ApiGroupNames } from 'src/app/models/enums/ApiGrouping.enum';
import { EnumPropertiesGroupModel, EnumPropertiesModel } from 'src/app/models/properties/PropertiesEnums.model';

@Injectable({
  providedIn: 'root'
})
export class PropertiesService extends HttpHandlerService {

  private readonly baseURL = 'properties';
  private cachedEnums: EnumPropertiesGroupModel[] = [];

  public getEnumsProperties(): Observable<EnumPropertiesGroupModel[]> {
    return this.fetchEnums();
  }

  public getEnumPropertiesByGroupName(groupNames: ApiGroupNames[]): Observable<EnumPropertiesModel[]> {
    return this.fetchEnums().pipe(
      map(allEnums => this.filterEnumsByGroupName(allEnums, groupNames))
    );
  }

  private fetchEnums(): Observable<EnumPropertiesGroupModel[]> {
    if (this.cachedEnums.length > 0) {
      return of(this.cachedEnums);
    }

    return this.get<EnumPropertiesGroupModel[]>(`${this.baseURL}/Enums`).pipe(
      tap(result => this.cachedEnums = result)
    );
  }

  private filterEnumsByGroupName(allEnums: EnumPropertiesGroupModel[], groupNames: ApiGroupNames[]): EnumPropertiesModel[] {
    if (groupNames.length === 0) {
      return allEnums.map(group => group.Enums).flat();
    }

    return allEnums
      .filter(group => groupNames.includes(group.GroupName as ApiGroupNames))
      .map(group => group.Enums).flat();
  }
}