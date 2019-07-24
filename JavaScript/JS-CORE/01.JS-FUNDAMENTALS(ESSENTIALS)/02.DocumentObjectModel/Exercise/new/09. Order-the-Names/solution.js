function solve() {
    let addButton = document.getElementsByTagName("button")[0];
    let input = document.getElementsByTagName("input")[0];
    let lis = document.querySelectorAll("ol>li");
 
    addButton.addEventListener("click", () => {
        let name = formatInput(input.value);
        let firstLetter = name[0];
        let position = alphabetPosition(firstLetter);
 
        let li = lis[position];
        let names = li.innerHTML.split(", ").filter(x=> x!=="");
        console.log(names);
        names = names.concat(name);
        names.sort(sortFnc);
        li.innerHTML = names.join(", ");
 
        //input.value = "";
    });
 
    function alphabetPosition(char) {
        var code = char.toUpperCase().charCodeAt(0);
        return (code - 65);
    }
 
    function sortFnc(a, b) {
        if (a < b) {
            return -1;
        }
        if (b > a) {
            return 1;
        }
        return 0;
    }
 
    function formatInput(input) {
        return input[0].toUpperCase() + input.slice(1).toLowerCase();
    }
}