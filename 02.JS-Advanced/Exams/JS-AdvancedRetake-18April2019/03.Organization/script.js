class Organization{
    constructor(name, budget){
        this.name = name;
        this.employees = [];
        this.budget = budget;

        this.marketingBudget = budget*0.4;
        this.financeBudget = budget*0.25;
        this.productionBudget = budget*0.35;
    }

    get departmentsBudget(){
        return {
            marketing : this.marketingBudget, 
            finance : this.financeBudget,
            production : this.productionBudget
        }
    }

    add(employeeName, department, salary){
        if(this.departmentsBudget[department] < salary){
            return `The salary that ${department} department can offer to you Mr./Mrs. ${employeeName} is $${this.departmentsBudget[department]}.`
        }

        let currentEmployee = {
            employeeName,
            department,
            salary
        }

        this.employees.push(currentEmployee);
        this[`${department}Budget`] -= salary;

        return `Welcome to the ${department} team Mr./Mrs. ${employeeName}.`
    }

    employeeExists(employeeName){
        const index = this.employees.findIndex(e => e.employeeName === employeeName);
        const currentEmployee = this.employees[index];

        if(currentEmployee){
            return `Mr./Mrs. ${employeeName} is part of the ${currentEmployee.department} department.`
        } else {
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`
        }
    }

    leaveOrganization(employeeName){
        const index = this.employees.findIndex(e => e.employeeName === employeeName);
        const currentEmployee = this.employees[index];

        if(currentEmployee){
            this.employees.splice(index, 1);
            this[`${currentEmployee.department}Budget`] += currentEmployee.salary;

            return `It was pleasure for ${this.name} to work with Mr./Mrs. ${employeeName}.`
        } else {
            return `Mr./Mrs. ${employeeName} is not working in ${this.name}.`
        }
    }

    status(){
        let marketingDepartment = [];
        let financeDepartment = [];
        let productionDepartment = [];

        for (const currentEmployee of this.employees) {
            if(currentEmployee.department === 'marketing'){
                marketingDepartment.push(currentEmployee);
            } else if(currentEmployee.department === 'finance'){
                financeDepartment.push(currentEmployee);
            } else if(currentEmployee.department === 'production'){
                productionDepartment.push(currentEmployee);
            }
        }

        let output = `${this.name.toUpperCase()} DEPARTMENTS:`;
        output += `\nMarketing | Employees: ${marketingDepartment.length}:`
        output += marketingDepartment.length === 0?'' : ` ${marketingDepartment.sort((a, b) => b.salary - a.salary).map(e => e.employeeName).join(', ')}`
        output += ` | Remaining Budget: ${this.departmentsBudget['marketing']}`;
       
        output += `\nFinance | Employees: ${financeDepartment.length}:`
        output += financeDepartment.length === 0?'' : ` ${financeDepartment.sort((a, b) => b.salary - a.salary).map(e => e.employeeName).join(', ')}`
        output += ` | Remaining Budget: ${this.departmentsBudget['finance']}`;
 
        output += `\nProduction | Employees: ${productionDepartment.length}:`
        output += productionDepartment.length === 0?'' : ` ${productionDepartment.sort((a, b) => b.salary - a.salary).map(e => e.employeeName).join(', ')}`
        output += ` | Remaining Budget: ${this.departmentsBudget['production']}`;

        return output;
    }
}

let organization = new Organization('SBTech', 1000);

console.log(organization.add('Peter', 'marketing', 800));
console.log(organization.add('Robert', 'production', 300));
console.log(organization.employeeExists('Robert'));
console.log(organization.leaveOrganization('Robert'));
console.log(organization.leaveOrganization('Robert'));
console.log(organization.employeeExists('Robert'));
console.log(organization.add('Peter', 'production', 200));
console.log(organization.add('Petko', 'production', 20));

console.log(organization.status());

