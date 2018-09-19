<template>
  <div class="about">
    <h1>This is an about page</h1>
    <h2>notes:</h2>
    <article v-for="note in notes" :key="note.id">
      <p>{{note.id}}</p>
      <p>{{note.text}}</p>
    </article>
  </div>
</template>

<script>
    import axios from '../axios-client';

    export default {
      data() {
          console.log(process.env);
          return {
              notes: []
          }
      },
      
      created() {
          console.log(process.env);
          axios.get('notes').then(response => {
              this.notes = response.data;
          }).catch(error => {
              console.log(error);
          });
      }
  }
</script>