export interface IBaseAdapter<T> {

    adaptToModel(plainObject: Object): T;
}