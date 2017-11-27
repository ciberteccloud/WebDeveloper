export default function DefaultParams() {
    let defaultCustomer = {
        "id": "",
        "firstName": "",
        "lastName": "",
        "city": "",
        "country": "",
        "phone": ""
    };

    return {
        customerReducer: {
            token: "",
            customers: Array<any>(),
            customer: defaultCustomer
        }
    };
}