($ => {
  'use strict';

  console.log('Request sending..');
  $.ajax('https://jsonplaceholder.typicode.com/todos/1').then(val => {
    console.log(val);
    console.log('Done');
  });
})(jQuery);
