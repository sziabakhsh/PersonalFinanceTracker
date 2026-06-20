import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

import { Button, Form, Card } from "react-bootstrap";

import { useCreateCategory } from "../hooks/useCreateCategory";

const schema = yup.object().shape({
  name: yup.string().required("Name is required"),
});

type FormData = {
  name: string;
};

export function CategoryForm() {

  const { mutate, isPending } = useCreateCategory();

  const {
    register,
    handleSubmit,
    reset,
    formState: { errors }
  } = useForm<FormData>({
    resolver: yupResolver(schema),
  });

  const onSubmit = (data: FormData) => {

    mutate(data, {
      onSuccess: () => {
        reset(); // 👈 clear form
      }
    });

  };

  return (
    <Card>
      <Card.Header>Add Category</Card.Header>

      <Card.Body>

        <Form onSubmit={handleSubmit(onSubmit)}>

          <Form.Group>
            <Form.Label>Name</Form.Label>

            <Form.Control
              {...register("name")}
              placeholder="Enter category name"
            />

            <p className="text-danger">
              {errors.name?.message}
            </p>

          </Form.Group>
          <Form.Group>
                <Form.Label>Type</Form.Label>
                <div className='mb-3'>
                    <select {...register("type")} className='form-select'>
                        <option value="">Select Type</option>
                        <option value="Income">Income</option>
                        <option value="Expense">Expense</option>
                    </select>
                </div>
            </Form.Group>
 
          <Button
            type="submit"
            className="mt-3"
            disabled={isPending}
          >
            {isPending ? "Saving..." : "Save"}
          </Button>

        </Form>

      </Card.Body>
    </Card>
  );
}