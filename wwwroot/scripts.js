window.initScrollListener = () => {
  const scrollContainer = document.querySelector("#numlist");
  document.addEventListener("wheel", (evt) => {
    scrollContainer.scrollLeft += evt.deltaY;
  });
};
