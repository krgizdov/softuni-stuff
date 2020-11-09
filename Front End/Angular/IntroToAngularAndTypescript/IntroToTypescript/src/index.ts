import * as _ from 'underscore';
import { test } from "./other"

interface IObj {
    name: string;
    age: number;
    data: boolean[];
}

interface IObjBig {
    size: number
}

interface IMyObj extends IObj, IObjBig {
    test: string[]
}

class User {
    constructor(public name: string, public age: number = 5) { }

    doSth() {
        return _.range(1, 10, 1);
    }

    doSthElse(obj: IObj) {

    }

    doSthSthElse<T extends IObj>(obj: T): T {
        return obj;
    }
}

class Employee extends User {

}

const user = new User("Ivan", 25);
const emp = new Employee('employee');

const obj: IMyObj = {
    name: "test",
    age: 5,
    data: [true, false, true],
    test: ['test', "5"],
    size: 10
};

emp.doSthElse(
    {
        name: "test",
        age: 5,
        data: [true, false, true]
    }
)

console.log(test);


