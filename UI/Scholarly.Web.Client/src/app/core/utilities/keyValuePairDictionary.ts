import { Type } from "@angular/core"

export class KeyValueDictionary<T extends string, U>
{
    private _map = new Map<T, U>();

    get length(){
        return this._map.values.length;
    }

    constructor(...pairs: {key: T, value: U}[]){
        pairs.forEach(pair=>{
            this._map.set(pair.key, pair.value);
        })
    }
    add(key: T, value: U): void{
        this._map.set(key, value);
    }
    get(key: T): U | undefined{
        return this._map.get(key);
    }
    contains(key: T): boolean{
        return Array.from(this._map.entries()).some(([_key, value])=> _key == key);
    }
    getAll(): {key: T, value: U}[]{
        return Array.from(this._map.entries()).map(([key, value])=> ({
            key,
            value
        }));
    }
}