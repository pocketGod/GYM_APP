import { ApiGroupNames } from "../enums/ApiGrouping.enum";


export interface EnumPropertiesGroupModel {
    GroupName: ApiGroupNames;
    Enums: EnumPropertiesModel[];
}
  
export interface EnumPropertiesModel {
    EnumName: string;
    EnumValues: EnumPropertiesValueModel[];
}

export interface EnumPropertiesValueModel {
    Name: string;
    Value: number;
    Summary: string;
}