import { ApiGroupNames } from "../enums/ApiGrouping.enum";


export interface EnumPropertiesGroupModel {
    groupName: ApiGroupNames;
    enums: EnumPropertiesModel[];
}
  
export interface EnumPropertiesModel {
    enumName: string;
    enumValues: EnumPropertiesValueModel[];
}

export interface EnumPropertiesValueModel {
    name: string;
    value: number;
    summary: string;
}