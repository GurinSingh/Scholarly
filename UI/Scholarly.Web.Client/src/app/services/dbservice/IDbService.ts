import { Observable } from "rxjs";

export interface IDbService<T>{
    getAll():Observable<T[]>;
    getById(id: number): Observable<T>;
    insert(entity:T):Observable<void>;
    update(entity: T): Observable<void>;
    delete(id:number): Observable<void>;
}