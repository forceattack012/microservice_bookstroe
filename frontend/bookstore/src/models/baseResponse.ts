export class BaseResponse<T> {
    statusCode: Number;
    message: String;
    isSuccess: boolean;
    data: T;
}