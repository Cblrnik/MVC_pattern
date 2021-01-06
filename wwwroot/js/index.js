const menuItem = document.getElementById('menuItem');
const menu = document.getElementById('hidemenu');

console.log(menuItem.offsetLeft);
menu.style.left = menuItem.getBoundingClientRect().left + "px";
menuItem.addEventListener('click',()=>{
    menu.classList.toggle('open');
});
    