import Table from "react-bootstrap/Table";
import Spinner from "react-bootstrap/Spinner";
import Alert from "react-bootstrap/Alert";
import Card from "react-bootstrap/Card";

import { useCategories } from "../hooks/useCategories";

export default function CategoryGrid() {

  const {
    data,
    isLoading,
    error
  } = useCategories();

  if (isLoading) {
    return (
      <Card>
        <Card.Body className="text-center">
          <Spinner />
        </Card.Body>
      </Card>
    );
  }

  if (error) {
    return (
      <Alert variant="danger">
        Failed to load categories
      </Alert>
    );
  }

  if (!data?.length) {
    return (
      <Alert variant="info">
        No categories found
      </Alert>
    );
  }

  return (
    <Card>
      <Card.Header>
        Categories
      </Card.Header>
      <Card.Body>
        <Table
          striped
          hover
          responsive
        >
          <thead>
            <tr>
              <th>Name</th>
              <th>Type</th>
            </tr>
          </thead>
          <tbody>
            {data.map(category => (
              <tr
                key={category.id}
              >
                <td>
                  {category.name}
                </td>
                <td>
                  {category.type}
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Card.Body>
    </Card>
  );
}