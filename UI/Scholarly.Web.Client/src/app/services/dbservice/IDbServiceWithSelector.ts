import { Observable } from "rxjs";
import { IDbService } from "./IDbService";

export interface IDbServiceWithSelector<T> extends IDbService<T>{
    getBySelector(selector: string): Observable<T>;
    updateBySelector(selector: string): Observable<void>;
    deleteBySelector(selector:string): Observable<void>;
}