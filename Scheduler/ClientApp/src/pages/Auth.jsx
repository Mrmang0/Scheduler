import {
  Box,
  Button,
  Container,
  Grid,
  makeStyles,
  Paper,
  TextField
} from "@material-ui/core";
import React from "react";
import { useForm } from "react-hook-form";
import { useDispatch } from "react-redux";
import { USER_LOGIN } from "../redux/actions";

const useStyles = makeStyles(theme => ({
  container: {
    height: "100vh",
    display: "flex",
    alignItems: "center"
  }
}));

export default function Auth() {
  const classes = useStyles();
  const { register, handleSubmit, reset, errors } = useForm();
  const dispatch = useDispatch();
  const submit = value => {
    // console.log(dispatch(USER_LOGIN));
  };

  console.log("parent rerender");

  return (
    <Container maxWidth="xs" className={classes.container}>
      <Paper>
        <form onSubmit={handleSubmit(submit)}>
          <Box p={4}>
            <Grid container spacing={2}>
              <Grid container item>
                <TextField
                  name="email"
                  label="Email"
                  fullWidth
                  inputRef={register}
                  error={errors.email}
                />
              </Grid>
              <Grid container item>
                <TextField
                  name="password"
                  label="password"
                  type="password"
                  fullWidth
                  inputRef={register}
                />
              </Grid>
              <Grid container item justify="center" spacing={2}>
                <Grid item>
                  <Button variant="contained" color="primary" type="submit">
                    Log in
                  </Button>
                </Grid>
                <Grid item>
                  <Button variant="contained" color="secondary" onClick={reset}>
                    clear
                  </Button>
                </Grid>
              </Grid>
            </Grid>
          </Box>
        </form>
      </Paper>
    </Container>
  );
}
