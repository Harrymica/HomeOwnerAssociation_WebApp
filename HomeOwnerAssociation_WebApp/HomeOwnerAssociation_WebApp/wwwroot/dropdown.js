window.showDropdownMenu = () => {
    const dropdownMenu = document.querySelector('.absolute.right-0.z-10.mt-2');
    dropdownMenu.classList.toggle('hidden');
}

window.closeDropdownMenu = () => {
    const dropdownMenu = document.querySelector('.absolute.right-0.z-10.mt-2');
    dropdownMenu.classList.add('hidden');
}
