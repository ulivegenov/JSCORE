class Computer {
    constructor(ramMemory, cpuGHz, hddMemory){
        this.ramMemory = ramMemory;
        this.cpuGHz = cpuGHz;
        this.hddMemory = hddMemory;

        this.taskManager = [];
        this.installedPrograms = [];
    }

    installAProgram(name, requiredSpace){
        if(this.hddMemory < requiredSpace){
            throw new Error('There is not enough space on the hard drive');
        }

        let currentProgram = {
            name,
            requiredSpace
        }

        this.installedPrograms.push(currentProgram);
        this.hddMemory -= requiredSpace;
        
        return currentProgram;
    }

    uninstallAProgram(name){
        let index = this.installedPrograms.findIndex(p => p.name === name);
        let currentProgram = this.installedPrograms[index];

        if(!currentProgram){
            throw new Error('Control panel is not responding');
        }

        this.installedPrograms.splice(index, 1);
        this.hddMemory += currentProgram.requiredSpace;

        return this.installedPrograms;
    }

    openAProgram(name){
        let index = this.installedPrograms.findIndex(p => p.name === name);
        let currentProgram = this.installedPrograms[index];

        if(!currentProgram){
            throw new Error(`The ${name} is not recognized`);
        }

        let isProgramOpenedindex = this.taskManager.findIndex(p => p.name === name);
        let isProgramOpened = this.taskManager[isProgramOpenedindex];

        if(isProgramOpened){
            throw new Error(`The ${name} is already open`);
        }

        let ramUsage = (currentProgram.requiredSpace / this.ramMemory) * 1.5;
        let cpuUsage = (currentProgram.requiredSpace / this.cpuGHz/500) * 1.5;

        if(ramUsage + this.getTottalRamUsage() >= 100){
            throw new Error(`${currentProgram.name} caused out of memory exception`);
        }

        if(cpuUsage + this.getTottalCPUUsage() >= 100){
            throw new Error(`${currentProgram.name} caused out of cpu exception`);
        }

        let currentOpenProgram = {
            name,
            ramUsage,
            cpuUsage
        }

        this.taskManager.push(currentOpenProgram);

        return currentOpenProgram;
    }

    taskManagerView(){
        if(this.taskManager.length === 0){
            return 'All running smooth so far';
        }

        let output = [];

        for (const program of this.taskManager) {
            output.push(`Name - ${program.name} | Usage - CPU: ${program.cpuUsage.toFixed(0)}%, RAM: ${program.ramUsage.toFixed(0)}%`);
        }

        return output.join('\n');
    }

    getTottalRamUsage(){
        let totalRamUsage = 0;

        for (const program of this.taskManager) {
            totalRamUsage += program.ramUsage;
        }

        return totalRamUsage;
    }

    getTottalCPUUsage(){
        let totalCPUUsage = 0;

        for (const program of this.taskManager) {
            totalCPUUsage += program.cpuUsage;
        }

        return totalCPUUsage;
    }
}

let computer = new Computer(4096, 7.5, 250000);

computer.installAProgram('Word', 7300);
computer.installAProgram('Excel', 10240);
computer.installAProgram('PowerPoint', 12288);
computer.installAProgram('Solitare', 1500);

computer.openAProgram('Word');
computer.openAProgram('Excel');
computer.openAProgram('PowerPoint');
computer.openAProgram('Solitare');

console.log(computer.taskManagerView());

